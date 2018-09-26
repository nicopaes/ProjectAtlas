public interface ITarget
{
    bool GazedAt
    {
        get;
        set;
    }

    bool ExecutedAction
    {
        get;
        set;
    }

    void SetGazedAt(bool newGazed);

    void GazedAtAction(bool gazedAt);
    
    void Action();
}