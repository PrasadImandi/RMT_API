import api from "@/lib/axiosInstance";

export const dropdownApi = {
    fetchRegions: async () => {
        const res = await api.get("/Master/regions");
        return res.data;
    },

    fetchStates: async () => {
        const res = await api.get("/Master/states");
        return res.data;
    },

    fetchLocations: async () => {
        const res = await api.get("/Master/Location");
        return res.data;
    },

    fetchAccessTypes: async () => {
        const res = await api.get("/Master/accessTypes");
        return res.data;
    },

    fetchDomian: async () => {
        const res = await api.get("/Master/domain");
        return res.data;
    },

    fetchDomianRoles: async () => {
        const res = await api.get("/Master/DomainRole");
        return res.data;
    },

    fetchDomianelevels: async () => {
        const res = await api.get("/Master/DomainLevel");
        return res.data;
    },

    fetchContactTypes: async () => {
        const res = await api.get("/Master/ContactType");
        return res.data;
    },

    fetchDeliveryMotions: async () => {
        const res = await api.get("/Master/DeliveryMotion");
        return res.data;
    },

    fetchLaptopProviders: async () => {
        const res = await api.get("/Master/LaptopProvider");
        return res.data;
    },

    fetchLeaveTypes: async () => {
        const res = await api.get("/Master/LeaveType");
        return res.data;
    },

    fetchManagerTypes: async () => {
        const res = await api.get("/Master/ManagerType");
        return res.data;
    },

    fetchPincodes: async () => {
        const res = await api.get("/Master/PinCode");
        return res.data;
    },

    fetchSegments: async () => {
        const res = await api.get("/Master/segment");
        return res.data;
    },

    fetchSupportTypes: async () => {
        const res = await api.get("/Master/supportType");
        return res.data;
    },
};
