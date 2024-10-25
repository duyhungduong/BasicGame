
public enum State {
    ALIVE,
    DEAD,
    GAMEOVER
}

public class Player {
    public int bloods{get;set;}
    public int remainingLives{get;set;}
    public State current{get;set;}

    public Player(int bloods, int remainingLives) {
        this.bloods = bloods;
        this.remainingLives = remainingLives;
        this.current = State.ALIVE;
    }

    public void handlerMonster(EventArg a) {
        Console.WriteLine("Player {0}", this.current);

        switch (this.current)
        {
            case State.ALIVE:
                Console.WriteLine("Hit by monster force {0}", a.value);

                if (this.bloods > a.value) {
                    this.bloods -= a.value;
                } else if (remainingLives > 0) {
                    remainingLives--;
                    this.current = State.DEAD;
                } else {
                    this.current = State.GAMEOVER;
                }
                break;            
            default:
                throw new Exception("Invalid event");
        }
    }

    public void handlerHeal(EventArg a) {
        Console.WriteLine("Current {0}", this.current);

        switch (this.current)
        {
             case State.ALIVE:
                Console.WriteLine("Blood pumping {0}", a.value);

                this.bloods += a.value;
                break;            
            default:
                throw new Exception("Invalid event");
        }
    }

    public void handlerRestart(EventArg a) {
        Console.WriteLine("Current {0}", this.current);

        switch (this.current)
        {
             case State.DEAD:
                Console.WriteLine("Restart");

                this.bloods = a.value;
                this.current = State.ALIVE;
                break;            
            default:
                throw new Exception("Invalid event");
        }
    }

    public void handleEvent(EventArg a) {
        switch (a.eventAction)
        {   
            case EventAction.MONSTER:
                handlerMonster(a);
                break;              
            case EventAction.HEAL:
                handlerHeal(a);
                break;              
            case EventAction.RESTART:
                handlerRestart(a);
                break;              
            default:
                throw new Exception("Invalid event");
        }
    }
}