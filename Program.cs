public class Program {
    static void Main() {
        Action ac = new Action();
        Player p = new Player(100, 1);
        ac.Process += p.handleEvent;

        EventArg e = new EventArg();

        try {
            e.eventAction = EventAction.MONSTER;
            e.value = 30;
            ac.OnProcess(e);
            
            e.eventAction = EventAction.MONSTER;
            e.value = 30;
            ac.OnProcess(e);

            e.eventAction = EventAction.MONSTER;
            e.value = 30;
            ac.OnProcess(e);

            e.eventAction = EventAction.MONSTER;
            e.value = 30;
            ac.OnProcess(e);

            e.eventAction = EventAction.RESTART;
            e.value = 100;
            ac.OnProcess(e);

            e.eventAction = EventAction.MONSTER;
            e.value = 60;
            ac.OnProcess(e);

            e.eventAction = EventAction.MONSTER;
            e.value = 50;
            ac.OnProcess(e);

            e.eventAction = EventAction.RESTART;
            e.value = 100;
            ac.OnProcess(e);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}