import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'searchFilter'
})

export class FilterSearch implements PipeTransform {
    transform(value: any, args: string): any {
        if (args == null || args == undefined) {
            return value;
        }
        else {
            let filter = args.toLocaleLowerCase();
            return filter ? value.filter(employee => (employee.lastName.toLocaleLowerCase().indexOf(filter) != -1)
                || (employee.firstName.toLocaleLowerCase().indexOf(filter) != -1)
                || (employee.serial.toLocaleLowerCase().indexOf(filter) != -1) 
                || (employee.assignment.toLocaleLowerCase().indexOf(filter) != -1)) : value;
        }
    }
}