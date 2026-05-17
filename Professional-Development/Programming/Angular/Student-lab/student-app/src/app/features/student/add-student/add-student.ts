import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IStudentAdd } from '../../../_models/IStudentAdd';
import { Router } from '@angular/router';
import { StudentService } from '../../../_services/student-service';

@Component({
  selector: 'app-add-student',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-student.html',
  styleUrl: './add-student.css',
})

export class AddStudent {
  // Initialize with default values
  newStudent:IStudentAdd = {
    stId: 0,
    stFname: '',
    stLname: '',
    stAddress: '',
    stAge: 0,
  };

  studentService = inject(StudentService);

  constructor(private router: Router) {}

  saveStudent() {
    console.log('Saving Student:', this.newStudent);
    // Here you would typically call a service to push to your array
    this.studentService.addStudent(this.newStudent).subscribe((addedStudent) => {
      console.log('Student added successfully:', addedStudent);
    });
    
    // Redirect back to the list after saving
    this.router.navigate(['/home']);
  }

  onCancel() {
    this.router.navigate(['/home']);
  }
}
