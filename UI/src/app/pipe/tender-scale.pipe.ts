import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'tenderScalePipe'
})
export class TenderScalePipe implements PipeTransform {

  transform(value: number): string {
    let result = 'Small'
    if (value >= 50000 && value < 100000){
      result = 'Medium';      
    }
    else if (value >= 100000 && value < 10000000){
      result = 'Big';      
    }
    else if (value >= 1000000 && value < 100000000 ){
      result = 'Huge';      
    }
    else if (value >= 10000000){
      result = 'Whale';      
    }

    return result;
  }

}
