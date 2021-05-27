using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectBehaviours
{
    move,
    rotate
}

public class ObjectBehaviourBuilder
{
    private readonly ObjectSample objectSample;
    private readonly List<ObjectDataBehaviour> behaviours;

    private readonly Dictionary<string, IObjectBehaviour> objectBehaviourDict =
        new Dictionary<string, IObjectBehaviour>
        {
            {ObjectBehaviours.move.ToString(), new MoveBehaviour()},
            {ObjectBehaviours.rotate.ToString(), new RotateBehaviour()}
        };

    public ObjectBehaviourBuilder(ObjectSample objectSample, List<ObjectDataBehaviour> behaviours)
    {
        this.objectSample = objectSample;
        this.behaviours = behaviours;
    }

    public ObjectBehaviourBuilder AttachCombinedBehaviour(int lowIndex, int highIndex)
    {
        for (int i = lowIndex; i < highIndex; i++)
        {
            objectSample.ObjectBehaviourList.Add(new Queue<ObjectActionContainer>());
            objectSample.ObjectBehaviourList[objectSample.ObjectBehaviourList.Count - 1]
                .Enqueue(InitObjectActionContainer(i));
        }

        return this;
    }

    public ObjectBehaviourBuilder AttachQueueBehaviour(int lowIndex, int highIndex)
    {
        if (objectSample.ObjectBehaviourList.Count == 0)
            objectSample.ObjectBehaviourList.Add(new Queue<ObjectActionContainer>());

        for (int i = lowIndex; i < highIndex; i++)
        {
            objectSample.ObjectBehaviourList[objectSample.ObjectBehaviourList.Count - 1]
                .Enqueue(InitObjectActionContainer(i));
        }

        return this;
    }

    private ObjectActionContainer InitObjectActionContainer(int i)
    {
        return new ObjectActionContainer
        {
            ObjectBehaviour = objectBehaviourDict[behaviours[i].Type],
            FromVector = new Vector3(behaviours[i].From[0], behaviours[i].From[1], behaviours[i].From[2]),
            ToVector = new Vector3(behaviours[i].To[0], behaviours[i].To[1], behaviours[i].To[2]),
            TimeAction = behaviours[i].Time
        };
    }
}
