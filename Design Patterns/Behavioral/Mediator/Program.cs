namespace Mediator
{
    public static class Program
    {
        public static void Main()
        {
            var chatRoom = new ChatRoom();

            Participant george = new Beetle("George"); // new Beetle("George", chatRoom);
            chatRoom.Register(george);

            Participant paul = new Beetle("Paul");
            chatRoom.Register(paul);

            Participant ringo = new Beetle("Ringo");
            chatRoom.Register(ringo);

            Participant john = new Beetle("John");
            chatRoom.Register(john);

            Participant yoko = new NonBeetle("Yoko");
            chatRoom.Register(yoko);

            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");

            yoko.SendToAll("Hi, all!");

            /*
             * Alternative:
             * Meet Paul with George and vice-versa
             * Meet Ringo with Paul and vice-versa
             * Meet Ringo with George and vice-versa
             * Meet John with Paul and vice-versa
             * Meet John with George and vice-versa
             * Meet John with Ringo and vice-versa
             * Meet Yoko with Paul and vice-versa
             * Meet Yoko with George and vice-versa
             * Meet Yoko with Ringo and vice-versa
             * Meet Yoko with John and vice-versa
             */
        }
    }
}
