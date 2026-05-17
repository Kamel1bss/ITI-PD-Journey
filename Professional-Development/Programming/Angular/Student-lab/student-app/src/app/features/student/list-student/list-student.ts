import { Component, inject, OnInit, signal, Signal } from '@angular/core';
import { StudentService } from '../../../_services/student-service';
import { RouterLink } from "@angular/router";
import { IStudent } from '../../../_models/istudent';

@Component({
  selector: 'app-list-student',
  imports: [RouterLink],
  templateUrl: './list-student.html',
  styleUrl: './list-student.css',
})
export class ListStudent {
  studentServices = inject(StudentService);
  students = signal([] as IStudent[]);

  constructor() {
    this.studentServices.getAllStudents().subscribe((data) => {
      this.students.set(data);
      console.log(this.students());
    });
  }

  // student.component.ts
onDelete(id: number) {
  console.log('Deleting student with id:', id);
  
  this.studentServices.deleteStudent(id).subscribe({
    next: () => {
      console.log('Delete successful');
      // Update local state: remove the student from the array
      this.students.set(this.students().filter(student => student.stId !== id));
    },
    error: (err) => {
      console.error('Delete failed:', err);
    }
  });
}

}
