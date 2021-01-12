import { Guid } from "guid-typescript";

export class BloodWork {
    Id: Guid = Guid.create();
    DateCreated: Date = new Date();
    ExamDate: Date = new Date();
    ResultsDate: Date = new Date();
    Description: string = "";
    Hemoglobin: number = 0;
    Hematocrit: number = 0;
    WhiteBloodCellCount: number = 0;
    RedBloodCellCount: number = 0;
} 

export class BloodWorkList {
    Records: BloodWork[] = [];
}
