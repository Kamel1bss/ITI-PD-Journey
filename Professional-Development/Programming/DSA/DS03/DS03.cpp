#include <iostream>
using namespace std;

struct Node {
    int data;
    Node* left;
    Node* right;

public:
    Node(int data) {
        this->data = data;
        left = right = nullptr;
    }
};

class BSTree {
private:
    Node* root = nullptr;
    Node* insert(Node* node, int data) {
        if (!node) return new Node(data);

        if (data < node->data)
            node->left = insert(node->left, data);
        else
            node->right = insert(node->right, data);

        return node;
    }

public:
    void addNode(int data) {
        root = insert(root, data);
    }

    void preorder(Node* root) {
        if (!root)
            return;
        cout << root->data << " ";
        preorder(root->left);
        preorder(root->right);
    }

    void postorder(Node* root) {
        if (!root)
            return;
        postorder(root->left);
        postorder(root->right);    
        cout << root->data << " ";
    }

    void inorder(Node* root) {
        if (!root)
            return;
        inorder(root->left);
        cout << root->data << " ";
        inorder(root->right);
    }

    Node* getRoot() {
        return root;
    }
};

int main() {
    BSTree b;
    b.addNode(4);
    b.addNode(3);
    b.addNode(5);

    cout << "Preorder: ";
    b.preorder(b.getRoot());   // 4 3 5
    cout << "\nInorder: ";
    b.inorder(b.getRoot());    // 3 4 5
    cout << "\nPostorder: ";
    b.postorder(b.getRoot());  // 3 5 4
}