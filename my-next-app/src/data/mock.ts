import { Resource, Project, Shift, Holiday } from "@/types";

export const mockResources: Resource[] = [
  {
    id: "1",
    name: "Devanjan Nanda",
    role: "Frontend Developer",
    skills: ["React", "TypeScript", "Tailwind"],
    imageUrl: "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=400",
    availability: true
  },
  {
    id: "2",
    name: "Durga Prasad",
    role: "Backend Developer",
    skills: [".Net", "Python", "AWS"],
    imageUrl: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=400",
    availability: true
  }
];


export const mockProjects: Project[] = [
  {
    id: "1",
    name: "HRMS Redesign",
    description: "Redesigning the HRMS application UI/UX",
    startDate: "2024-03-01",
    endDate: "2024-06-30",
    resources: mockResources
  },
  {
    id: "2",
    name: "Mobile App Development",
    description: "Developing mobile application for HR processes",
    startDate: "2024-04-01",
    endDate: "2024-08-31",
    resources: mockResources
  }
];

export const mockShifts: Shift[] = [
  {
    id: "1",
    resourceId: "1",
    projectId: "1",
    startTime: "09:00",
    endTime: "17:00",
    type: "morning",
    date: "2024-03-20"
  },
  {
    id: "2",
    resourceId: "2",
    projectId: "2",
    startTime: "13:00",
    endTime: "21:00",
    type: "afternoon",
    date: "2024-03-20"
  }
];

export const mockHolidays = [
  {
    id: "1",
    name: "New Year's Day",
    date: "2024-01-01",
    isPublic: true,
    description: "New Year's Day celebration"
  },
  {
    id: "2",
    name: "Christmas",
    date: "2024-12-25",
    isPublic: true,
    description: "Christmas Day celebration"
  },
  {
    id: "3",
    name: "Good Friday",
    date: "2024-03-29",
    isPublic: true,
    description: "Good Friday observance"
  }
];

export const mockLeaveTypes = [
  {
    id: 1,
    name: "Earned Leave",
    code: "EL",
    description: "Annual earned leave",
    defaultDays: 15
  },
  {
    id: 2,
    name: "Personal Leave",
    code: "PL",
    description: "Personal time off",
    defaultDays: 12
  },
  {
    id: 3,
    name: "Sick Leave",
    code: "SL",
    description: "Medical leave",
    defaultDays: 10
  }
] as const;

export const mockLeaveBalance = [
  {
    id: "1",
    userId: "1",
    leaveTypeId: 1,
    total: 15,
    used: 5,
    pending: 2,
    year: 2024
  },
  {
    id: "2",
    userId: "1",
    leaveTypeId:2,
    total: 12,
    used: 3,
    pending: 0,
    year: 2024
  },
  {
    id: "3",
    userId: "1",
    leaveTypeId: 3,
    total: 10,
    used: 1,
    pending: 1,
    year: 2024
  }
];

export const mockLeaveRequests = [
  {
    id: "1",
    userId: "1",
    leaveTypeId: 1,
    startDate: "2024-04-01",
    endDate: "2024-04-03",
    reason: "Family vacation",
    status: "approved",
    appliedOn: "2024-03-15"
  },
  {
    id: "2",
    userId: "1",
    leaveTypeId: 3,
    startDate: "2024-03-25",
    endDate: "2024-03-25",
    reason: "Doctor's appointment",
    status: "pending",
    appliedOn: "2024-03-20"
  }
] as const;