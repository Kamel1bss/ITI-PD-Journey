import { inject, Injectable, OnInit } from '@angular/core';
import { IStudent } from '../_models/istudent';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStudentAdd } from '../_models/IStudentAdd';

@Injectable({
  providedIn: 'root',
})

export class StudentService {
  httpClient = inject(HttpClient);
  url:string = 'https://localhost:7189/api/Students/';

  getAllStudents():Observable<IStudent[]> {
    return this.httpClient.get<IStudent[]>(this.url);
  }

  getStudentById(id: number): Observable<IStudent> {
    return this.httpClient.get<IStudent>(`${this.url}${id}`);
  }

  addStudent(student: IStudentAdd): Observable<IStudent> {
    return this.httpClient.post<IStudent>(this.url, student);
  }

  updateStudent(updatedStudent: IStudent): void {
    this.httpClient.put(`${this.url}${updatedStudent.stId}`, updatedStudent);
  }

  deleteStudent(id: number): Observable<any> {
    return this.httpClient.delete(`${this.url}${id}`);
  }
}
