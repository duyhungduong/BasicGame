public enum EventAction {
    MONSTER,
    HEAL,
    RESTART
}

public class EventArg {
    public EventAction eventAction{get;set;}
    
    public int value{get;set;}
}

public delegate void Notify(EventArg a);

public class Action {
    public event Notify Process;

    public void Occur(EventArg a) {
        OnProcess(a);
    }

    public void OnProcess(EventArg a) {
        Process?.Invoke(a);
    }
}