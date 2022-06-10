import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'tenderIdPipe'
})
export class TenderIdPipe implements PipeTransform {

  transform(num: number, totalLength: number): string {
    return String(num).padStart(totalLength, '0');
  }

}
