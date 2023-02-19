import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'overviewFilter',
    pure: false
})
export class OverviewFilterPipe implements PipeTransform {
    transform(items: any[], callback: (item: any) => boolean): any { // eslint-disable-line @typescript-eslint/no-explicit-any
        if (!items || !callback) {
            return items;
        }

        return items.filter(item => callback(item));
    }
}