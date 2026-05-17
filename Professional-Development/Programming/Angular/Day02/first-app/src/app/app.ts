import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListStudents } from "./components/student/list-students/list-students";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ListStudents],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('first-app');
}
