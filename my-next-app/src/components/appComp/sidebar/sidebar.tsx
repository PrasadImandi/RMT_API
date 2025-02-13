"use client";
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
} from "lucide-react";
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";
import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupLabel,
  SidebarHeader,
  SidebarTrigger,
} from "@/components/ui/sidebar";
import { Button } from "../../ui/button";
import { useSidebar } from "@/components/ui/sidebar";
import { useRouter, usePathname } from "next/navigation";
import { useState } from "react";
import SidebarListItem from "./sidebar-listitem";
import { useUserStore } from "@/store/userStore";
import { ADMIN_GROUPS, MAIN_MENU, SUPPLIER_GROUPS } from "./constants";

export function AppSidebar() {
  const params = usePathname();
  const router = useRouter();
  const [activeItem, setActiveItem] = useState<string>(params);
  const { user, logout } = useUserStore();

  const { open, state } = useSidebar();
  const handleLogout = async () => {
    console.log("logged out");
    router.push("/login");
    logout();
  };

  return (
    <Sidebar collapsible="icon" className="shadow-right">
      {state === "expanded" ? (
        <>
          <SidebarHeader className="flex gap-y-4 pt-5 w-full">
            <div className="flex w-full items-center">
              <SidebarTrigger />
              <div className="flex w-full justify-between items-center">
                <SidebarGroupLabel className="text-2xl text-primary-one font-medium">
                  {MAIN_MENU.title}
                </SidebarGroupLabel>
                <SidebarGroupLabel className="gap-2">
                  <TooltipProvider>
                    <Tooltip>
                      <TooltipTrigger asChild>
                        <Button
                          variant="ghost"
                          size="icon"
                          className="border border-black rounded-sm h-7 w-7"
                          onClick={handleLogout}
                        >
                          <LogOut className="border-black" />
                        </Button>
                      </TooltipTrigger>
                      <TooltipContent>
                        <p>Logout</p>
                      </TooltipContent>
                    </Tooltip>
                  </TooltipProvider>
                </SidebarGroupLabel>
              </div>
            </div>
          </SidebarHeader>

          {/* Main Menu Group */}
          <SidebarGroup className="pt-8">
            <SidebarContent className="flex flex-row justify-start items-center w-full">
              <div className="w-full">
                <ul className="w-full px-4">
                  {MAIN_MENU.items.map((item) => (
                    <SidebarListItem
                      key={item.href}
                      href={item.href}
                      icon={item.icon}
                      label={item.label}
                      isActive={activeItem === item.href}
                      onClick={() => setActiveItem(item.href)}
                    />
                  ))}
                </ul>
              </div>
            </SidebarContent>
          </SidebarGroup>

          {/* Conditional Group: Administration for admin users */}
          {user && user.role === "admin" && (
            <SidebarGroup>
              <SidebarGroupLabel className="text-2xl text-primary-one font-medium">
                {ADMIN_GROUPS.title}
              </SidebarGroupLabel>
              <SidebarContent className="flex flex-row justify-start items-center w-full">
                <div className="w-full">
                  <ul className="w-full px-4">
                    {ADMIN_GROUPS.items.map((item) => (
                      <SidebarListItem
                        key={item.href}
                        href={item.href}
                        icon={item.icon}
                        label={item.label}
                        isActive={activeItem === item.href}
                        onClick={() => setActiveItem(item.href)}
                      />
                    ))}
                  </ul>
                </div>
              </SidebarContent>
            </SidebarGroup>
          )}

          {/* Conditional Group: Supplier Menu for supplier users */}
          {user && user.role === "supplier" && (
            <SidebarGroup>
              <SidebarGroupLabel className="text-2xl text-primary-one font-medium">
                {SUPPLIER_GROUPS.title}
              </SidebarGroupLabel>
              <SidebarContent className="flex flex-row justify-start items-center w-full">
                <div className="w-full">
                  <ul className="w-full px-4">
                    {SUPPLIER_GROUPS.items.map((item) => (
                      <SidebarListItem
                        key={item.href}
                        href={item.href}
                        icon={item.icon}
                        label={item.label}
                        isActive={activeItem === item.href}
                        onClick={() => setActiveItem(item.href)}
                      />
                    ))}
                  </ul>
                </div>
              </SidebarContent>
            </SidebarGroup>
          )}
        </>
      ) : (
        <div className="flex flex-col w-full h-full py-2 justify-between items-center">
          <SidebarTrigger />
          <Button
            variant="ghost"
            size="icon"
            className="border border-black rounded-sm h-7 w-7"
            onClick={handleLogout}
          >
            <LogOut className="border-black" />
          </Button>
        </div>
      )}
    </Sidebar>
  );
}
