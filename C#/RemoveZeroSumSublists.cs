/**
Given the head of a linked list, we repeatedly delete consecutive sequences of nodes that sum to 0 until there are no such sequences.

After doing so, return the head of the final linked list.  You may return any such answer.

(Note that in the examples below, all sequences are serializations of ListNode objects.)
**/
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next

public class Solution {
    public ListNode RemoveZeroSumSublists(ListNode head) {
            Dictionary<int, ListNode> dict1 = new Dictionary<int, ListNode>();
            Dictionary<ListNode, int> dict2 = new Dictionary<ListNode, int>();
            ListNode tempNode1 = head,
                     tempNode2 = null;
            int sum = 0;

            while (tempNode1 != null)
            {
                sum += tempNode1.val;

                if (sum == 0)
                {
                    tempNode2 = head;

                    while (tempNode2 != tempNode1)
                    {
                        if (dict2.ContainsKey(tempNode2))
                            dict1.Remove(dict2[tempNode2]);

                        tempNode2 = tempNode2.next;
                    }

                    head = tempNode1.next;
                    tempNode1 = tempNode1.next;
                }
                else if (dict1.ContainsKey(sum))
                {
                    tempNode2 = dict1[sum].next;

                    while (tempNode2 != tempNode1)
                    {
                        if (dict2.ContainsKey(tempNode2))
                            dict1.Remove(dict2[tempNode2]);

                        tempNode2 = tempNode2.next;
                    }

                    dict1[sum].next = tempNode1.next;
                    tempNode1 = tempNode1.next;
                }
                else
                {
                    dict1.Add(sum, tempNode1);
                    dict2.Add(tempNode1, sum);

                    tempNode1 = tempNode1.next;
                }
            }

            return head;
    }
}
