import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { StudentService } from '../../../_services/student-service';
import { IStudent } from '../../../_models/istudent';

@Component({
  selector: 'app-student-details',
  imports: [CommonModule, RouterLink],
  templateUrl: './student-details.html',
  styleUrl: './student-details.css',
})
export class StudentDetails {
  student = signal({} as IStudent);

  studentService = inject(StudentService);
  route = inject(ActivatedRoute);
  router = inject(Router);

  constructor(){

    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.studentService.getStudentById(id).subscribe((student) => {
      this.student.set(student);
    });

    // If student doesn't exist, send them back home
    if (!this.student()) {
      this.router.navigate(['/home']);
    }
  }
  
}