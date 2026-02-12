#include <iostream>
using namespace std;

#pragma region Stack

struct Student {
    int id;
};

struct Node {
    Student data;
    Node* next;
};

class Stack {
    Node* top;
public:
    int size;
    Stack() {
        top = nullptr;
        size = 0;
    }

    void push(Student s) {
        Node* ptr = new Node;
        if (ptr) {
            ptr->data = s;
            ptr->next = top;
            top = ptr;
        }
        size++;
    }

    Node* pop() {
        if (isEmpty()) {
            cout << "Stack is empty\n";
            return nullptr;
        }
        size--;
        Node* temp = top;
        top = top->next;
        return temp;
    }

    bool isEmpty() {
        return top == nullptr;
    }

    void display() {
        Node* curr = top;
        while (curr != nullptr) {
            cout << curr->data.id << " ";
            curr = curr->next;
        }
        cout << endl;
    }
};
#pragma endregion

#pragma region Queue

#define SIZE 5
class Queue {
private:
    int arr[SIZE];
    int rear;

public:
    Queue() {
        rear = -1;
    }

    bool isEmpty() {
        return  rear == -1;
    }

    bool isFull() {
        return rear == SIZE - 1;
    }

    void enqueue(int x) {
        if (isFull()) {
            cout << "Queue Overflow\n";
            return;
        }

        rear++;
        arr[rear] = x;
    }

    int dequeue() {
        if (isEmpty()) {
            cout << "Queue is empty\n";
            return -1;
        }

        int val = arr[0];
        for (int i = 0; i < 4; i++) {
            arr[i] = arr[i + 1];
        }
        rear--;
        return val;
    }

    int getFront() {
        if (isEmpty()) {
            cout << "Queue is empty\n";
            return -1;
        }
        return arr[0];
    }

    void display() {
        if (isEmpty()) {
            cout << "Queue is empty\n";
            return;
        }
        for (int i = 0; i <= rear; i++)
            cout << arr[i] << " ";
        cout << endl;
    }
};
#pragma endregion



int main()
{
    Stack s;

    Student st[4] = { 1, 2, 3, 4 };
    s.push(st[0]);
    s.push(st[1]);
    s.push(st[2]);
    s.push(st[3]);
    
    cout << "[STACK]\n";
    cout << "====================\n";
    Node* deleted = s.pop();
    cout << "Deleted : " << deleted->data.id << "\n";
    s.display();


    Queue q;
    
    int arr[4] = { 1, 2, 3, 4 };
    q.enqueue(arr[0]);
    q.enqueue(arr[1]);
    q.enqueue(arr[2]);
    q.enqueue(arr[3]);


    cout << "\n\n\n[QUEUE]\n";
    cout << "====================\n";
    int deleted2 = q.dequeue();
    cout << "Deleted : " << deleted2 << "\n";
    q.display();


}