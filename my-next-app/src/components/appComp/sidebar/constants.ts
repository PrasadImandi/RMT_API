import { MenuItem, SidebarGroup } from './types';
import {
    LayoutDashboard,
    User2,
    LogOut,
    Clock5,
    FolderOpenDot,
    Container,
    Notebook,
    CalendarFold,
    CalendarDays,
    CalendarDaysIcon,
    Info,
    Users,
    Grid,
} from 'lucide-react';

export const MAIN_MENU: SidebarGroup = {
  title: "Main Menu" ,
  items:[  
  { href: "/admin", icon: LayoutDashboard, label: "Dashboard" },
  { href: "/admin/timesheet", icon: Clock5, label: "Timesheets" },
  { href: "/admin/roster-management", icon: CalendarFold, label: "Roster Management" },
  { href: "/admin/apply-leaves", icon: CalendarDays, label: "Apply Leaves" },
  { href: "/admin/report", icon: Notebook, label: "Reports" },
]
};

export const ADMIN_GROUPS: SidebarGroup = 
  {
    title: "Administration",
    items: [
        { href: "/admin/manage-client", icon: User2, label: "Manage Client" },
        { href: "/admin/manage-user", icon: User2, label: "Manage Users" },
        {
          href: "/admin/manage-project",
          icon: FolderOpenDot,
          label: "Manage Projects",
        },
        {
          href: "/admin/manage-resource",
          icon: Users,
          label: "Manage Resources",
        },
        {
          href: "/admin/manage-supplier",
          icon: Container,
          label: "Manage Suppliers",
        },
        {
          href: "/admin/publicholidays",
          icon: CalendarDaysIcon,
          label: "Public Holidays",
        },
    ]
  }


export const SUPPLIER_GROUPS: SidebarGroup = 
  {
    title: "Supplier Menu",
    items: [
        {
            href: "/supplier/resource-information",
            icon: Info,
            label: "Resource Information",
          },
          {
            href: "/supplier/project-overview",
            icon: Grid,
            label: "Project Overview",
          },
    ]
  }
