export class AuditoriumType {
    constructor(
        id?: number,
        auditoriumAbbreviation?: string,
        auditoriumName?: string) {
        this.id = id;
        this.auditoriumName = auditoriumName;
        this.auditoriumAbbreviation = auditoriumAbbreviation;
    }
    public id: number;
    public auditoriumAbbreviation: string;
    public auditoriumName: string;
}