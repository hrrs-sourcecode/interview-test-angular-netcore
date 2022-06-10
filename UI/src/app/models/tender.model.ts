export class Tender {
    id!:number;
    tenderID!:string;
    contractNo!:string;
    tenderName!:string;
    tenderValue!:number;
    description!:string;
    releaseDate!:Date;
    closingDate!:Date;    
    createdBy?:string;
    createdDate?:Date;
    modifiedBy?:string;
    modifiedDate?:Date;
}
