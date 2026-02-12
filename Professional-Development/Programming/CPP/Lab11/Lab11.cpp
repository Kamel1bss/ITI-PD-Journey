#include <iostream>
using namespace std;

class Shape {
protected:
    int dim1, dim2;
public:
    Shape() {
        dim1 = dim2 = 0;
    }

    Shape(int m) {
        dim1 = dim2 = m;
    }

    Shape(int m, int n) {
        dim1 = m, dim2 = n;
    }

    void setD1(int d) { dim1 = d;}
    void setD2(int d) { dim2 = d;}
    int getD1() { return dim1;}
    int getD2() { return dim2;}

    virtual float Area() = 0;
};
class Circle : public Shape {
public:
    Circle(){}
    Circle(int r) : Shape(r){}
    float Area() {
        return 3.14 * dim1 * dim2;
    }
};
class Rectangle : public Shape {
public:
    Rectangle(){}
    Rectangle(int m, int n) : Shape(m, n){}
    float Area() { return dim1 * dim2; }
};
class Square : public Rectangle {
public:
    Square(){}
    Square(int x) : Rectangle(x, x){}
    float Area() { return dim1 * dim2; }
};
class Triangle : public Shape {
public:
    Triangle() {}
    Triangle(int m, int n) : Shape(m, n){}
    float Area() { return .5 * dim1 * dim2; }
};

class GeoShape {
    Shape** arr;
    int size;
public:
    GeoShape(int _size, Shape** shapes){
        size = _size;
        this->arr = new Shape*[size];
        for (int i = 0; i < size; i++) {
            arr[i] = shapes[i];
        }
    }

    float TotalArea() {
        float sum = 0;
        for (int i = 0; i < size; i++) {
            sum += arr[i]->Area();
        }

        return sum;
    }

    ~GeoShape() {
        delete[] arr;
    }
};
int main()
{
    Circle c(5); // 78.5
    Rectangle r(4, 6); // 24
    Triangle t(3, 4); // 6

    Shape* shapes[] = { &c, &r, &t };
    GeoShape geo(3, shapes);
    cout << "Circle Area: " << c.Area() << endl;
    cout << "Rectangle Area: " << r.Area() << endl;
    cout << "Triangel Area: " << t.Area() << endl;
    cout << "Total Area: " << geo.TotalArea() << endl;
}
