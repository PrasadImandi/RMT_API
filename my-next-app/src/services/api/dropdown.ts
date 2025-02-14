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
};
