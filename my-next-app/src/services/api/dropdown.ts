import api from "@/lib/axiosInstance";

export const dropdownApi = {
  fetchRegions: async () => {
    const res = await api.get("/DropDown/regions");
    return res.data;
  },

  fetchStates: async () => {
    const res = await api.get("/DropDown/states");
    return res.data;
  },

  fetchAccessTypes:async () => {
    const res = await api.get("/AccessType");
    return res.data;
  },

  fetchDomian:async () => {
    const res = await api.get("/DropDown/domain");
    return res.data;
  },

  fetchDomianROles:async () => {
    const res = await api.get("/DropDown/domainroles");
    return res.data;
  },

  fetchDomianelevels:async () => {
    const res = await api.get("/DropDown/domainlevels");
    return res.data;
  },
};
