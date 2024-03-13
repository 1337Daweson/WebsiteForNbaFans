import axios from 'axios';

/**
 * HttpRequestService:
 *
 * A service handeling API requests. All functions return type is Axios promise.
 *
 * Powered by Axios (via npm)
 */
export default class HttpRequestor {
  static #API_URL = 'http://localhost:5121';

  static #AXIOS_REQUEST_CONFIG = {
    headers: { 'Content-Type': 'application/json' },
  };

  /**
     * JS Date Transformer - transforms JS dates to format accepted by API
     */
//   static dateTransformer = (data) => {
//     if (data instanceof Date) {
//       return DateTransformer.toISOLocale(data);
//     }
//     if (Array.isArray(data)) {
//       return http://data.map(val => this.dateTransformer(val));
//     }
//     if (typeof data === 'object' && data !== null) {
//       return Object.fromEntries(Object.entries(data).map(([key, val]) => [key, this.dateTransformer(val)]));
//     }
//     return data;
//   };

  static #axios = axios.create();

  /**
     * Generic get
     *
     * 
@param
 {string} url
     */
  static get(url, params = {}, relative = true) {
    url = relative ? `${this.#API_URL}/${url}` : url;
    params
    return this.#axios.get(
      url, {
        params,
      },
    );
  }

  /**
     * Generic post
     *
     * 
@param
 {string} url
     * 
@param
 {any} data
     */
  static post(url, data, params = null) {
    data = this.dateTransformer(data);
    return this.#axios.post(
      `${this.#API_URL}/${url}`,
      data,
      {
        ...this.#AXIOS_REQUEST_CONFIG,
        params,
      },
    );
  }
}