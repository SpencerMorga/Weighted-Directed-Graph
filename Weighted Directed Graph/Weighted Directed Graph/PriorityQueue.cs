using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weighted_Directed_Graph
{
    public class PriorityQueue<T>
    {
        private T[] tree = new T[30];
        private IComparer<T> comparer;

        /// <summary>
        /// Amount of items in the queue
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If the queue is empty
        /// </summary>
        /// <returns>True if the queue is empty</returns>
        public bool IsEmpty() => Count == 0;

        /// <summary>
        /// Check if an item is inside the queue
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns>True if them exists</returns>
        public bool Contains(T item) => tree.Contains(item);

        /// <summary>
        /// Index through the all the items in the queue
        /// </summary>
        /// <param name="i">Index of the queue item</param>
        /// <returns>The value of the index</returns>
        public T this[int i]
        {
            get
            {
                if (i > -1 && i < Count)
                {
                    return tree[i];
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Count = 0;
        }

        /// <summary>
        /// Add an item to the queue
        /// </summary>
        /// <param name="value">Item to add</param>
        public void Enqueue(T value)
        {
            //Increase the count
            //If we reach the capacity of the queue increase it
            Count++;

            if (Count == tree.Length)
            {
                IncreaseTree();
            }

            //Store it in the queue
            //Then HeapifyUp to make sure that everything is balanced
            tree[Count] = value;

            HeapifyUp(Count);
        }

        /// <summary>
        /// Remove the top item for the queue
        /// </summary>
        /// <returns>The top item from the queue</returns>
        public T Dequeue()
        {
            //Sort the queue to get the top item
            //Then take the last item and move it to the top
            //Then HeapifyDown to make sure the everything is balanced with the removal            
            Sort();
            T root = tree[1];

            tree[1] = tree[Count];
            tree[Count] = default(T);

            Count--;

            HeapifyDown(1);

            return root;
        }

        /// <summary>
        /// Sort the queue
        /// </summary>
        private void Sort()
        {
            for (int i = Count / 2; i > 0; i--)
            {
                HeapifyDown(i);
            }
        }

        /// <summary>
        /// Heapify upwards
        /// </summary>
        /// <param name="index">Starting point</param>
        private void HeapifyUp(int index)
        {
            int parent = index / 2;

            //if we are the root or if our parent is the root or if we are the same value as our parent
            if (parent < 1 || comparer.Compare(tree[parent], tree[1]) == 0 || comparer.Compare(tree[index], tree[parent]) == 0)
            {
                return;
            }

            //if the current is smaller than its parent then swap them
            if (comparer.Compare(tree[index], tree[parent]) < 0)
            {
                T temp = tree[index];
                tree[index] = tree[parent];
                tree[parent] = temp;
            }

            HeapifyUp(parent);
        }

        /// <summary>
        /// Heapify downwards
        /// </summary>
        /// <param name="index">Starting point</param>
        private void HeapifyDown(int index)
        {
            int leftChild = index * 2;
            int rightChild = index * 2 + 1;

            int swapIndex = 0;

            //If we ran out of children stop
            if (leftChild > Count || rightChild > Count)
            {
                return;
            }

            //Swap the kids
            if (comparer.Compare(tree[leftChild], tree[rightChild]) < 0)
            {
                swapIndex = leftChild;
            }
            else
            {
                swapIndex = rightChild;
            }

            //Swap the main kid with the index
            if (comparer.Compare(tree[swapIndex], tree[index]) < 0)
            {
                T temp = tree[index];
                tree[index] = tree[swapIndex];
                tree[swapIndex] = temp;
            }

            HeapifyDown(swapIndex);
        }

        /// <summary>
        /// Double the size of the array
        /// </summary>
        private void IncreaseTree()
        {
            T[] temp = new T[tree.Length * 2];
            tree.CopyTo(temp, 0);
            tree = temp;
        }
    }
}
