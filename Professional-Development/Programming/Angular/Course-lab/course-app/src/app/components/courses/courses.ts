import { Component } from '@angular/core';
import { DUMMY_COURSES } from '../../DUMMY-COURSES';
import { NgStyle } from '@angular/common';
import { ICourse } from '../../interfaces/ICourse';
import { DUMMY_CATEGORIES } from '../../DUMMY-CATEGORIES';
import { FormsModule } from '@angular/forms';
import { ICategory } from '../../interfaces/ICategories';
@Component({
  selector: 'app-courses',
  imports: [NgStyle, FormsModule],
  templateUrl: './courses.html',
  styleUrl: './courses.css',
})

export class Courses {
  courses = DUMMY_COURSES;
  categories = DUMMY_CATEGORIES;

  onCategoryChange(selectedCategoryId: string) {
    const selectedCategory = this.categories.find(cat => cat.id === selectedCategoryId);
    if (selectedCategory) {
      this.courses = DUMMY_COURSES.filter(course => course.catId === selectedCategory.id);
    } else {
      this.courses = DUMMY_COURSES;
    }
  }

  onRegister(course: ICourse) {
    course.seats--;
  }
}
