import { AuditoriumType } from '../auditoriumType/auditoriumtype';

export class Auditorium{
    constructor(
        public id?: number,
        public auditoriumNumber?: string,
        public auditoriumCapacity?: number,
        public auditoriumTypeId?: number,
        public auditoriumType?: AuditoriumType) { }
}