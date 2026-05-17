import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Courses } from "./components/courses/courses";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Courses],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('course-app');
}
