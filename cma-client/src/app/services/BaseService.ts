export class BaseService {
    baseURL: string;
    constructor(controllerName: string) {
        this.baseURL = 'http://localhost:50376/api/' + controllerName + '/';
    }
}
