
const apiService = {

    getNoParams: async function (url) {
        try {
            const response = await fetch(url);      
            return await this.handleResponse(response);
        }
        catch (error) {
            return this.handleError(error);
        }
    },
    getWithParams: async function (props) {
        try {
            const url = new URL(props.url);

            Object.keys(props.params).forEach(key => url.searchParams.append(key, props.params[key]));

            const response = await fetch(url);
            return await this.handleResponse(response);
        }
        catch (error) {
            return this.handleError(error);
        }
    },

    postNoParams: async function (props) {
        try {
            const response = await fetch(props.url, { method: "POST" });
            return await this.handleResponse(response);
        }
        catch (error) {
            return this.handleError(error);
        }
    },
    postWithParams: async function (props) {
        try {
            const url = new URL(props.url);

            Object.keys(props.params).forEach(key => url.searchParams.append(key, props.params[key]));

            const response = await fetch(url, { method: "POST" });

            return await this.handleResponse(response);
        }
        catch (error) {
            return this.handleError(error);
        }
    },
    postWithJsonParams: async function (props) {
        await fetch(props.url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(props.data)
        });
    },

    handleResponse: async function (response) {
        if (!response.ok) {
            console.log(`HTTP Error! Status: ${response.status}`);
            return {msg: `HTTP Error! Status: ${response.status}` }
            //throw new Error(`HTTP Error! Status: ${response.status}`);
        }
        try {
            return response.json()  // Parse JSON
        }
        catch (error) {
            return { success : false, msg: `Invalid JSON response` }
            console.log("Invalid JSON response");
            //throw new Error("Invalid JSON response");
        }
    },

    handleError: function (error) {
        console.log("API Error:", error.message);
        return { success: false, error: error.message }; // Return a structured error object
    }
}

export default apiService;