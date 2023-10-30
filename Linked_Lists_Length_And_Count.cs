﻿using System;

namespace CodingChallenges;
[TestClass]
public class Linked_Lists_Length_And_Count {

    /*

    Linked Lists - Length & Count

    Implement Length() to count the number of nodes in a linked list.

    Node.Length(nullptr) => 0
    Node.Length(1 -> 2 -> 3 -> nullptr) => 3
    Implement Count() to count the occurrences of a that satisfy a condition provided by a predicate which takes in a node's Data value.

    Node.Count(null, value => value == 1) => 0
    Node.Count(1 -> 3 -> 5 -> 6, value => value % 2 != 0) => 3
    I've decided to bundle these two functions within the same Kata since they are both very similar.

    The push()/Push() and buildOneTwoThree()/BuildOneTwoThree() functions do not need to be redefined.

    */


    [TestMethod]
    public void Test() {

        Node list = BuildOneTwoThree();
        Assert.AreEqual(1, Node.Count(list, value => value == 1), "list should only contain one 1.");
        Assert.AreEqual(1, Node.Count(list, value => value == 2), "list should only contain one 2.");
        Assert.AreEqual(1, Node.Count(list, value => value == 3), "list should only contain one 3.");
        Assert.AreEqual(0, Node.Count(list, value => value == 99), "list should return zero for integer not found in list.");
        Assert.AreEqual(0, Node.Count(null, value => value == 1), "null list should always return count of zero.");

        Assert.AreEqual(2, Node.Count(list, value => value % 2 != 0), "list should contain two odd numbers.");
        Assert.AreEqual(1, Node.Count(list, value => value % 2 == 0), "list should contain one even number.");

        Assert.AreEqual(0, Node.Length(null), "Length of null list should be zero.");
        Assert.AreEqual(1, Node.Length(new Node(99)), "Length of single node list should be one.");
        Assert.AreEqual(3, Node.Length(list), "Length of the three node list should be three.");
    }

    public partial class Node {
        public int Data;
        public Node Next;

        public Node(int data) {
            this.Data = data;
            this.Next = null;
        }

        public static int Length(Node head) {
            return Count(head, value => true);
        }

        public static int Count(Node head, Predicate<int> func) {
            int count = 0;
            while (head != null) {
                if (func(head.Data)) count++;
                head = head.Next;
            }
            return count;
        }
    }

    public Node BuildOneTwoThree() {

        var n1 = new Node(1);
        var n2 = new Node(2);
        var n3 = new Node(3);

        n1.Next = n2;
        n2.Next = n3;

        //Node tmp = n1; while (tmp != null) { Console.WriteLine(tmp.Data);  tmp = tmp.Next; };

        return n1;
    }

}
