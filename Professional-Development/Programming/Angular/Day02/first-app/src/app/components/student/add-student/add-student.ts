import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IStudent } from '../../../models/istudent';
import { StudentService} from '../../../services/studentService'; // Use service instead

@Component({
  selector: 'app-add-student',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-student.html',
})
export class AddStudent {
  // Inject the Service, not the other Component
  private studentService = inject(StudentService);

  student: IStudent = { id: 0, name: '', age: 0 };

  addStudent() {
    if (this.student.id === 0) {
      // New Student logic
      this.studentService.addStudent(this.student);
    } else {
      // Update existing logic
      this.studentService.updateStudent(this.student);
    }
    
    // Reset form
    this.student = { id: 0, name: '', age: 0 };
  }
}