import { Routes } from '@angular/router';
import { ListStudent } from './features/student/list-student/list-student';
import { AddStudent } from './features/student/add-student/add-student';
import { EditStudent } from './features/student/edit-student/edit-student';
import { StudentDetails } from './features/student/student-details/student-details';

export const routes: Routes = [
    {"path":"home", component:ListStudent, title:"Student List"},
    {"path":"add-student", component:AddStudent, title:"Add Student"},
    {"path": 'edit-student/:id', component: EditStudent },
    {"path": 'student/:id', component: StudentDetails },

    {"path":"", redirectTo:"home", pathMatch:"full"},
    {"path":"**", redirectTo:"home"}
];
