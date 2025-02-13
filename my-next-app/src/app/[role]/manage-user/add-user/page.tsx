"use client";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import api from "@/lib/axiosInstance";
import { useRouter } from "next/navigation";
import { useEffect } from "react";
import { userFormSchema, UsersApi } from "@/services/api/users";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { dropdownApi } from "@/services/api/dropdown";

const CreateUser = () => {
  const router = useRouter();
  const queryClient = useQueryClient();

  const form = useForm({
    resolver: zodResolver(userFormSchema),
    defaultValues: {
      firstName: "",
      lastName: "",
      username: "",
      email: "",
      roleID: 0,
      isActive: false,
    },
  });

  const emailValue = form.watch("email");

  useEffect(() => {
    if (emailValue) {
      const [usernamePart] = emailValue.split("@");
      const currentUsername = form.getValues("username");
      if (!currentUsername) {
        form.setValue("username", usernamePart);
      }
    }
  }, [emailValue, form]);

  const { data: accestypes = [] } = useQuery({
    queryKey: ["accesstypes"],
    queryFn: dropdownApi.fetchAccessTypes,
  });

  const createClient = useMutation({
    mutationFn: UsersApi.createUser,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["users"] });
      form.reset();
      router.push("/admin/manage-user");
    },
  });

  const onSubmit = async (values: z.infer<typeof userFormSchema>) => {
    const [password] = values.email.split("@");
    const payload = {
      firstName: values.firstName,
      lastName: values.lastName,
      username: values.username,
      email: values.email,
      password: password,
      roleID: values.roleID,
      isActive: values.isActive,
    };

    console.log("Payload:", payload);

    createClient.mutate(payload);
  };

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Create User</h1>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="space-y-6 w-3/5"
        >
          {/* First Name Field */}
          <FormField
            control={form.control}
            name="firstName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>First Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter first name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Last Name Field */}
          <FormField
            control={form.control}
            name="lastName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Last Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter last name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Email Field */}
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input placeholder="Enter email" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Username Field */}
          <FormField
            control={form.control}
            name="username"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Username</FormLabel>
                <FormControl>
                  <Input placeholder="Enter username" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Role Field */}
          <FormField
            control={form.control}
            name="roleID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Role</FormLabel>
                <Select
                  onValueChange={(value) => field.onChange(Number(value))}
                  // Convert the number in field.value to a string for the select component
                  value={field.value ? field.value.toString() : ""}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a role" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {accestypes.map((accessType: any) => (
                      <SelectItem
                        key={accessType.id}
                        value={accessType.id.toString()}
                      >
                        {accessType.name}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Status Field */}
          <FormField
            control={form.control}
            name="isActive"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Status</FormLabel>
                <Select
                  // Convert the string value into a boolean when updating the form
                  onValueChange={(value) => field.onChange(value === "true")}
                  // Convert the boolean stored in field.value back to a string
                  value={
                    typeof field.value === "boolean"
                      ? field.value.toString()
                      : ""
                  }
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a status" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="true">Active</SelectItem>
                    <SelectItem value="false">Inactive</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Submit Button */}
          <Button type="submit">Create User</Button>
        </form>
      </Form>
    </div>
  );
};

export default CreateUser;
