'use client';

import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { Button } from '@/components/ui/button';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';

const loginSchema = z.object({
  username: z.string().min(1, 'Username is required'),
  password: z.string().min(8, 'Password must be at least 8 characters'),
});

const resetSchema = z.object({
  oldPassword: z.string().min(8, 'Old Password must be at least 8 characters'),
  newPassword: z.string().min(8, 'New Password must be at least 8 characters'),
});

export default function PeoplePulseLogin() {
  const [isResetMode, setIsResetMode] = useState(false);

  const form = useForm({
    resolver: zodResolver(isResetMode ? resetSchema : loginSchema),
    defaultValues: isResetMode
      ? { oldPassword: '', newPassword: '' }
      : { username: '', password: '' },
  });

  const onSubmit = (data) => {
    console.log('Form Submitted:', data);
  };

  return (
    <div className="flex h-screen items-center justify-center bg-gradient-to-r from-teal-400 to-blue-800">
      <div className="w-full max-w-md bg-white p-6 rounded-2xl shadow-lg">
        <h2 className="text-2xl font-bold text-center text-gray-700">
          {isResetMode ? 'Reset Password' : 'Welcome to PeoplePulse'}
        </h2>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="mt-4 space-y-4">
            {isResetMode ? (
              <>
                <FormField
                  control={form.control}
                  name="oldPassword"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Old Password</FormLabel>
                      <FormControl>
                        <Input type="password" placeholder="Enter old password" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="newPassword"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>New Password</FormLabel>
                      <FormControl>
                        <Input type="password" placeholder="Enter new password" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
              </>
            ) : (
              <>
                <FormField
                  control={form.control}
                  name="username"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Username</FormLabel>
                      <FormControl>
                        <Input type="text" placeholder="Enter username" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="password"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel>Password</FormLabel>
                      <FormControl>
                        <Input type="password" placeholder="Enter password" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
              </>
            )}

            <Button type="submit" className="w-full">
              {isResetMode ? 'Submit' : 'Login'}
            </Button>
            <Button
              type="button"
              onClick={() => setIsResetMode(!isResetMode)}
              className="w-full bg-gray-500 text-white hover:bg-gray-600"
            >
              {isResetMode ? 'Cancel' : 'Forgot Password?'}
            </Button>
          </form>
        </Form>
      </div>
    </div>
  );
}
