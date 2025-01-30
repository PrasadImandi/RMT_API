'use client';

import { useState, useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { Input } from '@/components/ui/input';
// import { PasswordPolicyIndicator } from '@/components/security/password-policy-indicator';
import { Loader2 } from 'lucide-react';
import { useRouter } from 'next/navigation';

// Authentication schemas
const loginSchema = z.object({
  username: z.string().min(1, 'username is required'),
  password: z.string().min(1, 'Password is required'),
});

const passwordResetSchema = z.object({
  currentPassword: z.string().min(8, 'Current password must be at least 8 characters'),
  newPassword: z.string().min(8, 'New password must meet security requirements')
    .regex(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/, 'Must contain uppercase, number, and special character'),
});

export default function PeoplePulseAuthGateway() {
  const [isResetting, setIsResetting] = useState(false);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [passwordStrength, setPasswordStrength] = useState(0);
  const router = useRouter()
  const form = useForm({
    resolver: zodResolver(isResetting ? passwordResetSchema : loginSchema),
    defaultValues: isResetting 
      ? { currentPassword: '', newPassword: '' }
      : { username: '', password: '' },
    mode: 'onBlur',
  });

  const handleAuthSubmission = async (data: z.infer<typeof loginSchema | typeof passwordResetSchema>) => {
    setIsSubmitting(true);
    try {
      // Simulate API call
      console.log('Authentication payload:', data);
      router.push('/admin')
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <div className="flex min-h-screen items-center justify-center bg-neutral-50">
      <div className="w-full max-w-md bg-white p-8 rounded-xl shadow-xl border border-gray-100">
        <div className="mb-6 flex justify-center">
        <img src="/PeoplePulseFinal1.png" height={50} width={50} />
        </div>
        
        <h1 className="text-center text-2xl font-semibold text-gray-900 mb-8">
          {isResetting ? 'Secure Password Reset' : 'Employee Authentication Portal'}
        </h1>

        <Form {...form}>
          <form onSubmit={form.handleSubmit(handleAuthSubmission)} className="space-y-6">
            {!isResetting ? (
              <>
                <FormField
                  control={form.control}
                  name="username"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel className="text-gray-700">Username</FormLabel>
                      <FormControl>
                        <Input
                          {...field}
                          placeholder="Enter your username"
                          className="focus:ring-2 focus:ring-primary-500"
                          autoComplete="username"
                        />
                      </FormControl>
                      <FormMessage className="text-danger-600" />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="password"
                  render={({ field }) => (
                    <FormItem>
                      <div className="flex justify-between items-center">
                        <FormLabel className="text-gray-700">Password</FormLabel>
                        <button
                          type="button"
                          onClick={() => setIsResetting(true)}
                          className="text-sm text-primary-600 hover:text-primary-800"
                        >
                          Reset Password?
                        </button>
                      </div>
                      <FormControl>
                        <Input
                          {...field}
                          type="password"
                          placeholder="Enter your password"
                          className="focus:ring-2 focus:ring-primary-500"
                          autoComplete="current-password"
                        />
                      </FormControl>
                      <FormMessage className="text-danger-600" />
                    </FormItem>
                  )}
                />
              </>
            ) : (
              <>
                <FormField
                  control={form.control}
                  name="currentPassword"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel className="text-gray-700">Current Password</FormLabel>
                      <FormControl>
                        <Input
                          {...field}
                          type="password"
                          placeholder="Verify current password"
                          className="focus:ring-2 focus:ring-primary-500"
                        />
                      </FormControl>
                      <FormMessage className="text-danger-600" />
                    </FormItem>
                  )}
                />
                <FormField
                  control={form.control}
                  name="newPassword"
                  render={({ field }) => (
                    <FormItem>
                      <FormLabel className="text-gray-700">New Password</FormLabel>
                      <FormControl>
                        <div className="space-y-2">
                          <Input
                            {...field}
                            type="password"
                            placeholder="Create new password"
                            className="focus:ring-2 focus:ring-primary-500"
                            onChange={(e) => {
                              field.onChange(e);
                              // Add password strength calculation
                            }}
                          />
                          {/* <PasswordPolicyIndicator strength={passwordStrength} /> */}
                        </div>
                      </FormControl>
                      <FormMessage className="text-danger-600" />
                    </FormItem>
                  )}
                />
              </>
            )}

            <Button 
              type="submit"
              className="w-full"
              disabled={isSubmitting}
            >
              {isSubmitting ? (
                <Loader2 className="h-4 w-4 animate-spin" />
              ) : isResetting ? (
                'Update Credentials'
              ) : (
                'Sign In'
              )}
            </Button>

            {isResetting && (
              <button
                type="button"
                onClick={() => setIsResetting(false)}
                className="w-full text-center text-sm text-gray-600 hover:text-gray-800"
              >
                Return to Login
              </button>
            )}
          </form>
        </Form>

        <div className="mt-8 text-center text-sm text-gray-500">
          <p>Secure access to PeoplePulse HRMS v2.4</p>
          <p className="mt-2">© {new Date().getFullYear()} Your Corporation. All rights reserved.</p>
        </div>
      </div>
    </div>
  );
}