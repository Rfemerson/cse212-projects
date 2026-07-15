using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue all of them.
    // Expected Result: The values should be returned from highest to lowest priority: High, Mid, Low.
    // Defect(s) Found: The last item in the queue was not evaluated, causing Mid to be returned instead of High.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Mid", 3);
        priorityQueue.Enqueue("High", 5);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();

        Assert.AreEqual("High", first);
        Assert.AreEqual("Mid", second);
        Assert.AreEqual("Low", third);
    }

    [TestMethod]
    // Scenario: Add two items with the same highest priority and one item with a lower priority.
    // Expected Result: Items with the same priority should be removed in FIFO order: First, Second, Low. 
    // Defect(s) Found: When two items had the same highest priority, the item added later was returned instead of the first item added.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Low", 1);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();

        Assert.AreEqual("First", first);
        Assert.AreEqual("Second", second);
        Assert.AreEqual("Low", third);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Add two items and dequeue twice.
    // Expected Result: The highest-priority item should be removed, so the second dequeue returns the remaining item.
    // Defect(s) Found: The dequeued item was returned but not removed from the queue, causing High to be returned again.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Low", 1);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("High", first);
        Assert.AreEqual("Low", second);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found:  No defects found.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}