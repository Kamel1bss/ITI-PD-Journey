import { Component, inject } from '@angular/core';
import { AddStudent } from '../add-student/add-student';
import { StudentService } from '../../../services/studentService';
import { IStudent } from '../../../models/istudent';

@Component({
  selector: 'app-list-students',
  imports: [AddStudent],
  templateUrl: './list-students.html',
  styleUrl: './list-students.css',
})
export class ListStudents {
  studentService = inject(StudentService);
  deleteStudent(id: number) {
    if (confirm('Are you sure you want to delete this student?')) {
      this.studentService.deleteStudent(id);
    }
  }

  prepareEdit(student: IStudent) {
  // Logic to send this student back to the AddStudent component form
    this.studentService.editStudent(student);
  // Usually done by having the AddStudent component watch the service
}
}
