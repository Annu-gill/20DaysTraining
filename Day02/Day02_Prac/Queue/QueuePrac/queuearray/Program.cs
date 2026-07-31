// using System;

// class QueueArray
// {
//     int[] queue = new int[5];
//     int front = 0;
//     int rear = -1;

//     public void Enqueue(int value)
//     {
//         if (rear == queue.Length - 1)
//         {
//             Console.WriteLine("Queue Full");
//             return;
//         }

//         queue[++rear] = value;
//     }

//     public void Dequeue()
//     {
//         if (front > rear)
//         {
//             Console.WriteLine("Queue Empty");
//             return;
//         }

//         Console.WriteLine("Deleted: " + queue[front++]);
//     }

//     public void Display()
//     {
//         for (int i = front; i <= rear; i++)
//         {
//             Console.WriteLine(queue[i]);
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         QueueArray q = new QueueArray();

//         q.Enqueue(10);
//         q.Enqueue(20);
//         q.Enqueue(30);

//         q.Display();

//         q.Dequeue();

//         Console.WriteLine("\nAfter Dequeue");

//         q.Display();
//     }
// }



using System;

class HospitalQueue
{
    string[] patient = new string[10];
    int front = 0;
    int rear = -1;

    public void RegisterPatient(string name)
    {
        if (rear == patient.Length - 1)
        {
            Console.WriteLine("Queue Full");
            return;
        }

        patient[++rear] = name;
        Console.WriteLine(name + " Registered");
    }

    public void CallNextPatient()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Calling: " + patient[front++]);
    }

    public void ViewNextPatient()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Next Patient: " + patient[front]);
    }

    public void DisplayWaitingPatients()
    {
        if (front > rear)
        {
            Console.WriteLine("No Patients Waiting");
            return;
        }

        Console.WriteLine("Waiting Patients:");

        for (int i = front; i <= rear; i++)
            Console.WriteLine(patient[i]);
    }

    public void SearchPatient(string name)
    {
        bool found = false;

        for (int i = front; i <= rear; i++)
        {
            if (patient[i].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Patient Found");
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Patient Not Found");
    }

    public void CountWaitingPatients()
    {
        Console.WriteLine("Waiting Patients: " + (rear - front + 1));
    }
}

class Program
{
    static void Main()
    {
        HospitalQueue hospital = new HospitalQueue();

        while (true)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("ABC Hospital Queue Management System");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Call Next Patient");
            Console.WriteLine("3. View Next Patient");
            Console.WriteLine("4. Display Waiting Patients");
            Console.WriteLine("5. Search Patient");
            Console.WriteLine("6. Count Waiting Patients");
            Console.WriteLine("7. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Patient Name: ");
                    string name = Console.ReadLine();
                    hospital.RegisterPatient(name);
                    break;

                case 2:
                    hospital.CallNextPatient();
                    break;

                case 3:
                    hospital.ViewNextPatient();
                    break;

                case 4:
                    hospital.DisplayWaitingPatients();
                    break;

                case 5:
                    Console.Write("Enter Patient Name: ");
                    string search = Console.ReadLine();
                    hospital.SearchPatient(search);
                    break;

                case 6:
                    hospital.CountWaitingPatients();
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}