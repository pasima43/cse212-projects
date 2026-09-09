using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue the highest priority item.
    // Expected Result: "banana" should be returned first because it has the highest priority.
    // Defect(s) Found: None found by this test (it passed even on the buggy code, since "cherry" wasn't the correct answer anyway, so the loop's off-by-one bug wasn't exposed).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 1);
        priorityQueue.Enqueue("banana", 5);
        priorityQueue.Enqueue("cherry", 3);

        Assert.AreEqual("banana", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items where the highest priority item is enqueued last.
    // Expected Result: "cherry" should be returned first because it has the highest priority, even though it was added last.
    // Defect(s) Found: The loop stopped one index too early (using _queue.Count - 1), so it never checked the last item in the queue, causing the wrong result when the highest priority item was last.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 1);
        priorityQueue.Enqueue("banana", 3);
        priorityQueue.Enqueue("cherry", 5);

        Assert.AreEqual("cherry", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

        [TestMethod]
    // Scenario: Add two items with the same highest priority.
    // Expected Result: "apple" should be returned first because it was added first (closest to the front).
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 5);
        priorityQueue.Enqueue("banana", 5);
        priorityQueue.Enqueue("cherry", 3);

        Assert.AreEqual("apple", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}