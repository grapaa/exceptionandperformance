import { check } from "k6";
import http from "k6/http";

export const options = {
    vus: 10,
    duration: "10s",
    insecureSkipTLSVerify: true
};

export default () => {
    const url = "https://localhost:7062/Exception/Functional";
    const res = http.get(url);

    check(res, {
        'is status 500': (r) => r.status === 500,
    });
}