
const apiService = {

    request: async function ({ url, method = "GET", data = null, contentType = "json", timeout = 30000 }) {
        const controller = new AbortController();
        const id = setTimeout(() => controller.abort(), timeout);

        const options = {
            method,
            headers: {},
            signal: controller.signal
        };

        if (data) {
            if (method.toUpperCase() === "GET" || contentType === null) {
                const query = new URLSearchParams(data).toString();  // Append query string
                url += (url.includes("?") ? "&" : "?") + query;
            }
            else if (contentType === "json") {
                options.body = JSON.stringify(data);
                options.headers["Content-Type"] = "application/json";
            }
            else if (contentType === "form") {
                options.headers["Content-Type"] = "application/x-www-form-urlencoded";
                options.body = typeof data === "string" ? data : new URLSearchParams(data).toString();
            }
        }

        try {
            //console.log('api url', url, 'options', options)
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
            const result = responseType.includes("application/json") ? await response.json() : await response.text();

            const data = result.data ?? result;
            const success = result.success ?? (result.data ? (result.data.success ?? true) : true);
            const error = success ? '' : result.msg;
            return { success: success, data: data, error: error };
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
    post: async function (url, data = null) {
        return await this.request({ url, method: "POST", data });
    },
    postJson: async function (url, data) {
        return await this.request({ url, method: "POST", data, contentType: "json" });
    },

    postForm: async function (url, data) {
        console.log('api postForm url', url, 'data', data);
        return await this.request({ url, method: "POST", data, contentType: "form" });
    }
};

export default apiService;
