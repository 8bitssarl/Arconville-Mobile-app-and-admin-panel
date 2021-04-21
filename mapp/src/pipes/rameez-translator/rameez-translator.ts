import { Pipe, PipeTransform } from '@angular/core';

/**
 * Generated class for the RameezTranslatorPipe pipe.
 *
 * See https://angular.io/api/core/Pipe for more info on Angular Pipes.
 */
@Pipe({
    name: 'rameezTranslator',
})
export class RameezTranslatorPipe implements PipeTransform {
    
    private defaultLang:string = 'en';

    transform(value: string, ...args) {
        //return value.toLowerCase();
        //console.log("RameezTranslatorPipe::args: "+args.length);
        let lang = this.defaultLang;
        if (args.length>0){
            lang=args[0];
            //console.log(lang);
        }
        if ((<any>window).rameez_languages){
            let langs=(<any>window).rameez_languages;
            if (langs[lang]){
                if (langs[lang][value]){
                    return langs[lang][value];
                }
                if (lang!=this.defaultLang && langs[this.defaultLang][value]){
                    return langs[this.defaultLang][value];
                }
            }
        }
        return value;
    }
}
