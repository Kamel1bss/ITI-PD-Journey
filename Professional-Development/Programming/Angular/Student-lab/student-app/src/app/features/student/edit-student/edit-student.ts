import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IStudent } from '../../../_models/istudent';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../../_services/student-service';

@Component({
  selector: 'app-edit-student',
  imports: [FormsModule, CommonModule],
  templateUrl: './edit-student.html',
  styleUrl: './edit-student.css',
})

export class EditStudent implements OnInit {
  student!: IStudent;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private studentService: StudentService
  ) {}

  ngOnInit() {
    // 1. Get the ID from the URL
    const id = Number(this.route.snapshot.paramMap.get('id'));
    
    // 2. Find the student in the service
    this.studentService.getStudentById(id).subscribe((existingStudent) => {
      if (existingStudent) {
        // Create a copy so we don't edit the original until "Save" is clicked
        this.student = { ...existingStudent };
      } else {

      // Redirect if student not found
      this.router.navigate(['/home']);
    }
  });
  }

  save() {
    this.studentService.updateStudent(this.student);
    this.router.navigate(['/home']);
  }

  cancel() {
    this.router.navigate(['/home']);
  }
 
}