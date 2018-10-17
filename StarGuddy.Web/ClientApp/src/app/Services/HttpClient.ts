import { HttpClient, HttpParams, HttpRequest } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';

@Injectable()
export class HttpService {

    private readonly apiUrl: string;

    constructor(
        @Inject("API_URL") apiUrl: string,
        @Inject(PLATFORM_ID) private platformId: Object,
        private http: HttpClient) {
        this.apiUrl = apiUrl;

    }

    private get UrlPrifix()
    {
        return this.apiUrl + "api/";
    }

    get(Url: string) {
        return this.http.get(this.UrlPrifix + Url);
    }

    getData<T>(Url: string) {
        return this.http.get<any>(this.UrlPrifix + Url);
    }

    post(Url: string, data: any) {
        return this.http.post(this.UrlPrifix + Url, data);
    }

    postData<T>(Url: string, data: any) {
        return this.http.post<any>(this.UrlPrifix + Url, data);
    } 

    postDataWithProgress<T>(Url: string, data: any) {
        return this.http.request<T>(
            new HttpRequest('POST', this.UrlPrifix + Url, data, { reportProgress: true })
        );
    }

    postSimple(Url: string, data: any) {
        return this.http.post<any>(this.UrlPrifix + Url, data);
    }

    patchData<T>(Url: string, data: any) {
        return this.http.patch<T>(this.UrlPrifix + Url, data);
    }

    putData<T>(Url: string, data: any) {
        return this.http.put<T>(this.UrlPrifix + Url, data);
    }

    deleteData<T>(Url: string, params: HttpParams) {
        return this.http.delete<T>(this.UrlPrifix + Url, {
            params: params
        });
    }
}
