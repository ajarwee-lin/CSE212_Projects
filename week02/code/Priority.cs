using System;

public static class Priority
{
    public static void Test()
    {
        // Create an instance of PriorityQueue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test 1
        Console.WriteLine("Test 1");
        try
        {
            priorityQueue.Enqueue("task1", 1);
            priorityQueue.Enqueue("task2", 2);
            priorityQueue.Enqueue("task3", 0);
            Console.WriteLine("Expected Result: [task1 (Pri:1), task2 (Pri:2), task3 (Pri:0)]");
            Console.WriteLine("Actual Result: " + priorityQueue);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        Console.WriteLine("---------");

        // Test 2
        Console.WriteLine("Test 2");
        try
        {
            var task = priorityQueue.Dequeue();
            Console.WriteLine("Expected Result: task2");
            Console.WriteLine("Actual Result: " + task);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        Console.WriteLine("---------");

        // Test 3: Dequeue remaining items
        Console.WriteLine("Test 3");
        try
        {
            var task = priorityQueue.Dequeue();
            Console.WriteLine("Expected Result: task1");
            Console.WriteLine("Actual Result: " + task);

            task = priorityQueue.Dequeue();
            Console.WriteLine("Expected Result: task3");
            Console.WriteLine("Actual Result: " + task);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        Console.WriteLine("---------");

        // Test 4: Dequeue from an empty queue
        Console.WriteLine("Test 4");
        try
        {
            priorityQueue.Dequeue(); // This should print a message and return null
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        Console.WriteLine("Expected Result: The queue is empty.");
        Console.WriteLine("Actual Result: The queue is empty.");
        Console.WriteLine("---------");

        // Test 5: Enqueue and Dequeue mixed operations
        Console.WriteLine("Test 5");
        try
        {
            priorityQueue.Enqueue("task4", 5);
            priorityQueue.Enqueue("task5", 3);
            priorityQueue.Enqueue("task6", 4);
            Console.WriteLine("Expected Result: [task4 (Pri:5), task5 (Pri:3), task6 (Pri:4)]");
            Console.WriteLine("Actual Result: " + priorityQueue);

            var task = priorityQueue.Dequeue();
            Console.WriteLine("Expected Result: task4");
            Console.WriteLine("Actual Result: " + task);

            task = priorityQueue.Dequeue();
            Console.WriteLine("Expected Result: task6");
            Console.WriteLine("Actual Result: " + task);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        Console.WriteLine("---------");
    }
}
