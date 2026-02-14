#include <iostream>

using namespace std;

int BinarySearch(int arr[], int n, int key){
    int start = 0;
    int end = n-1;
    while(start <= end){
        int mid = (start + end) / 2;
        if(arr[mid] == key){
            return mid;
        }
        else if(arr[mid] > key){
            end = mid - 1;
        }
        else{
            start = mid + 1;
        }
    }
    return -1;
}

void SelectionSort(int arr[], int n){
    for(int i = 0; i < n; i++){
        int min_index = i;
        for(int j = i+1; j < n; j++){
            if(arr[j] <= arr[min_index]){
                min_index = j;
            }
        }
        swap(arr[i], arr[min_index]);
    }
}

void InsertionSort(int arr[], int n){
    for(int i = 1; i < n; i++){
        int key = arr[i];
        int j = i - 1;
        while(arr[j] > key && j >= 0){
            arr[j+1] = arr[j];
            j--;
        }
        arr[j+1] = key;
    }
}


int main(){
    int arr[] = { 2, 3, 4, 10, 40 };
    int x = 10;
    int result = BinarySearch(arr, 5, x);
    if(result == -1) 
	cout << "Element is not present in array";
    else 
	cout << "Element is present at index " << result;

    int arr2[] = {4, 3, 7, 1, 6, 2};
    InsertionSort(arr2, sizeof(arr2) / sizeof(arr2[0]));
    for(int i: arr2){
        cout << i << "  ";
    } 

    int arr3[] = {4, 3, 7, 1, 6, 2};
    SelectionSort(arr3, sizeof(arr3) / sizeof(arr3[0]));
    for(int i: arr3){
        cout << i << "  ";
    }

    return 0;
}