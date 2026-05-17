import { Injectable } from '@angular/core';
import { IStudent } from '../models/istudent';

@Injectable({ providedIn: 'root' })
export class StudentService {
   students: IStudent[] = [
    { id: 1, name: 'John Doe', age: 20 },
    { id: 2, name: 'Jane Smith', age: 22 },
    { id: 3, name: 'Alice Johnson', age:  33},
    { id: 4, name: 'Bob Brown', age: 21 },
    { id: 5, name: 'Charlie Wilson', age: 31 },
    { id: 6, name: 'David Lee', age: 19 },
    { id: 7, name: 'Emily Davis', age: 24 },
    { id: 8, name: 'Frank Miller', age: 28 },
    { id: 9, name: 'Grace Taylor', age: 26 },
    { id: 10, name: 'Henry Anderson', age: 23 }
  ]
// DELETE: Remove by ID
  deleteStudent(id: number) {
    this.students = this.students.filter(s => s.id !== id);
  }
  selectedStudent: IStudent | null = null;

  editStudent(student: IStudent) {
    // Create a copy so we don't edit the list in real-time while typing
    this.selectedStudent = { ...student };
  }
  
  // UPDATE: Find the index and replace the object
  updateStudent(updatedStudent: IStudent) {
    const index = this.students.findIndex(s => s.id === updatedStudent.id);
    if (index !== -1) {
      this.students[index] = { ...updatedStudent };
    }
  }
  addStudent(newStudent: IStudent) {
    this.students.push({ ...newStudent });
  }
}