﻿
const apiService = {

    request: async function ({ url, method = "GET", data = null, contentType = "json", timeout = 8000 }) {

        const controller = new AbortController();
        const id = setTimeout(() => controller.abort(), timeout);

        const options = {
            method,
            headers: {},
            signal: controller.signal
        };

        if (data) {
            if (method.toUpperCase() === "GET") {
              
                const query = new URLSearchParams(data).toString();  // Append query string

                url += (url.includes("?") ? "&" : "?") + query;
            }
            else if (contentType === "json") {

                options.headers["Content-Type"] = "application/json";

                options.body = JSON.stringify(data);
            }
            else if (contentType === "form") {

                options.headers["Content-Type"] = "application/x-www-form-urlencoded";

                options.body = typeof data === "string"  ? data : new URLSearchParams(data).toString();
            }
        }

        try {
            const response = await fetch(url, options);
            clearTimeout(id);

            const responseType = (response.headers.get("Content-Type") || "").toLowerCase();

            if (!response.ok) {
                return {
                    success: false,
                    status: response.status,
                    error: `HTTP ${response.status}: ${response.statusText}`
                };
            }

            // Auto parse JSON or return text
            const result = responseType.includes("application/json") ? await response.json() : await response.text();

            return { success: true, data: result.data };
        }
        catch (error) {
            clearTimeout(id);
            return {
                success: false,
                error: error.name === "AbortError" ? "Request timed out" : error.message
            };
        }
    },

    get: async function (url, params = null) {
        return await this.request({ url, method: "GET", data: params });
    },

    postJson: async function (url, data) {
        return await this.request({ url, method: "POST", data, contentType: "json" });
    },

    postForm: async function (url, data) {
        console.log('url', url, 'data', data);
        return await this.request({ url, method: "POST", data, contentType: "form" });
    }
};

export default apiService;
