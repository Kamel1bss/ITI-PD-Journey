export interface ICourse {
    id: string;
    title: string;
    instructorId: string;
    price: number;
    seats: number; // Number of available seats
    catId: string; // Category ID
    imageUrl: string; // URL to the course image
}
