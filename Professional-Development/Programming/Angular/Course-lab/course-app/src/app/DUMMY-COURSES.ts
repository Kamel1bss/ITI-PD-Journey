import { ICourse } from "./interfaces/ICourse";

export const DUMMY_COURSES: ICourse[] = [
  {
    id: 'c101',
    title: 'Advanced Angular Architecture',
    instructorId: 'inst-77',
    price: 89.99,
    seats: 5,
    catId: 'cat-web',
    imageUrl: 'https://picsum.photos/seed/angular/300/200'
  },
  {
    id: 'c102',
    title: 'Mastering UI/UX Design',
    instructorId: 'inst-12',
    price: 45.00,
    seats: 0, // Out of stock example
    catId: 'cat-design',
    imageUrl: 'https://picsum.photos/seed/design/300/200'
  },
  {
    id: 'c103',
    title: 'Python for Data Science',
    instructorId: 'inst-05',
    price: 120.50,
    seats: 25,
    catId: 'cat-data',
    imageUrl: 'https://picsum.photos/seed/python/300/200'
  },
  {
    id: 'c104',
    title: 'Introduction to Cybersecurity',
    instructorId: 'inst-99',
    price: 0, // Free course example
    seats: 100,
    catId: 'cat-security',
    imageUrl: 'https://picsum.photos/seed/cyber/300/200'
  },
  {
    id: 'c105',
    title: 'Mobile App Development with Flutter',
    instructorId: 'inst-23',
    price: 65.00,
    seats: 12,
    catId: 'cat-web',
    imageUrl: 'https://picsum.photos/seed/flutter/300/200'
  },
  {
    id: 'c106',
    title: 'Mobile App Development with Flutter',
    instructorId: 'inst-23',
    price: 65.00,
    seats: 2,
    catId: 'cat-web',
    imageUrl: 'https://picsum.photos/seed/flutter/300/200'
  }
];